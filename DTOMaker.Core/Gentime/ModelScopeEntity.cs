﻿using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace DTOMaker.Gentime
{
    public abstract class ModelScopeEntity : ModelScopeBase
    {
        protected readonly TargetEntity _entity;

        public ModelScopeEntity(IModelScope parent, IScopeFactory factory, ILanguage language, TargetEntity entity)
            : base(parent, factory, language)
        {
            _entity = entity;
            _tokens["NameSpace"] = entity.EntityName.NameSpace;
            _tokens["EntityName"] = entity.EntityName.ShortName;
            _tokens["EntityName2"] = entity.EntityName.ShortName;
            _tokens["EntityId"] = entity.EntityId;
            _tokens["BaseName"] = entity.Base?.EntityName.ShortName ?? TypeFullName.DefaultBase.ShortName;
            _tokens["BaseNameSpace"] = entity.Base?.EntityName.NameSpace ?? TypeFullName.DefaultBase.NameSpace;
            _tokens["BaseFullName"] = entity.Base?.EntityName.FullName ?? TypeFullName.DefaultBase.FullName;
            _tokens["ClassHeight"] = entity.GetClassHeight();

            _tokens["DerivedEntityCount"] = _entity.DerivedEntities.Length;
        }

        private static bool IsDerivedFrom(TargetEntity candidate, TargetEntity parent)
        {
            if (ReferenceEquals(candidate, parent)) return false;
            if (candidate.Base is null) return false;
            if (candidate.Base.EntityName.Equals(parent.EntityName)) return true;
            return IsDerivedFrom(candidate.Base, parent);
        }

        public int DerivedEntityCount => _entity.DerivedEntities.Length;

        public ModelScopeMember[] Members
        {
            get
            {
                return _entity.Members.Values
                            .OrderBy(m => m.Sequence)
                            .Select(m => _factory.CreateMember(this, _factory, _language, m))
                            .ToArray();
            }
        }

        public ModelScopeEntity[] DerivedEntities
        {
            get
            {
                return _entity.DerivedEntities
                        .OrderBy(e => e.EntityName.FullName)
                        .Select(e => _factory.CreateEntity(this, _factory, _language, e))
                        .ToArray();
            }
        }

        protected override (bool?, IModelScope[]) OnGetInnerScopes(string iteratorName)
        {
            switch (iteratorName.ToLowerInvariant())
            {
                case "members":
                    var members = _entity.Members.Values
                            .OrderBy(m => m.Sequence)
                            .Select(m => _factory.CreateMember(this, _factory, _language, m))
                            .ToArray();
                    if (members.Length > 0)
                        return (true, members);
                    else
                        return (false, new IModelScope[] { ModelScopeEmpty.Instance });
                case "derivedentities":
                    var derivedEntities = _entity.DerivedEntities
                        .OrderBy(e => e.EntityName.FullName)
                        .Select(e => _factory.CreateEntity(this, _factory, _language, e))
                        .ToArray();
                    if (derivedEntities.Length > 0)
                        return (true, derivedEntities);
                    else
                        return (false, new IModelScope[] { ModelScopeEmpty.Instance });
                default:
                    return (null, Array.Empty<IModelScope>());
            }
        }
    }
}
