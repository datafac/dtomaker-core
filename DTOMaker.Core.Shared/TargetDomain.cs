﻿using Microsoft.CodeAnalysis;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DTOMaker.Gentime
{
    public abstract class TargetDomain : TargetBase
    {
        public string Name { get; }
        public ConcurrentDictionary<string, TargetEntity> Entities { get; } = new ConcurrentDictionary<string, TargetEntity>();
        public TargetDomain(string name, Location location) : base(location)
        {
            Name = name;
        }

        private SyntaxDiagnostic? CheckEntityIdsAreUnique()
        {
            var idMap = new Dictionary<int, TargetEntity>();

            foreach (var entity in this.Entities.Values.OrderBy(e => e.EntityName.FullName))
            {
                int id = entity.EntityId;
                if (idMap.TryGetValue(id, out var otherEntity))
                {
                    return new SyntaxDiagnostic(
                        DiagnosticId.DTOM0009, "Duplicate entity id", DiagnosticCategory.Design, Location, DiagnosticSeverity.Error,
                        $"Entity id ({id}) is already used by entity: {otherEntity.EntityName}");
                }
                idMap[id] = entity;
            }

            return null;
        }

        protected override IEnumerable<SyntaxDiagnostic> OnGetValidationDiagnostics()
        {
            SyntaxDiagnostic? diagnostic;
            if ((diagnostic = CheckEntityIdsAreUnique()) is not null) yield return diagnostic;
        }
    }
}
