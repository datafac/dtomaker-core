﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace DTOMaker.Gentime
{
    public abstract class TargetEntity : TargetBase
    {
        public TypeFullName EntityName { get; }

        private readonly TargetDomain _domain;
        public TargetDomain Domain => _domain;
        public ConcurrentDictionary<string, TargetMember> Members { get; } = new ConcurrentDictionary<string, TargetMember>();
        public TargetEntity(TargetDomain domain, string nameSpace, string name, Location location) : base(location)
        {
            EntityName = new TypeFullName(nameSpace, name);
            _domain = domain;
        }
        public string EntityId { get; set; } = "_undefined_entity_id_";
        public bool HasEntityAttribute { get; set; }
        public TypeFullName BaseName { get; set; } = TypeFullName.DefaultBase;
        public TargetEntity? Base { get; set; }
        public TargetEntity[] DerivedEntities { get; set; } = [];

        public int GetClassHeight() => Base is not null ? Base.GetClassHeight() + 1 : 1;

        private SyntaxDiagnostic? CheckHasEntityAttribute()
        {
            if (HasEntityAttribute) return null;
            return new SyntaxDiagnostic(
                        DiagnosticId.DTOM0006, "Missing [Entity] attribute", DiagnosticCategory.Design, Location, DiagnosticSeverity.Error,
                        $"[Entity] attribute is missing.");
        }

        private SyntaxDiagnostic? CheckMemberSequenceIsValid()
        {
            int expectedSequence = 1;
            foreach (var member in Members.Values.OrderBy(m => m.Sequence))
            {
                if (member.Sequence != expectedSequence)
                    return new SyntaxDiagnostic(
                        DiagnosticId.DTOM0003, "Invalid member sequence", DiagnosticCategory.Design, member.Location, DiagnosticSeverity.Error,
                        $"Expected member '{member.Name}' sequence to be {expectedSequence}, but found {member.Sequence}.");
                expectedSequence++;
            }
            return null;
        }

        protected override IEnumerable<SyntaxDiagnostic> OnGetValidationDiagnostics()
        {
            SyntaxDiagnostic? diagnostic;
            if ((diagnostic = CheckHasEntityAttribute()) is not null) yield return diagnostic;
            if ((diagnostic = CheckMemberSequenceIsValid()) is not null) yield return diagnostic;
        }
    }
}
