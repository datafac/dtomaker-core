﻿using DTOMaker.Gentime;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace DTOMaker.CSRecord
{
    internal class CSRecordSyntaxReceiver : SyntaxReceiverBase
    {
        private static TargetDomain DomainFactory(string name, Location location) => new CSRecordDomain(name, location);
        private static TargetEntity EntityFactory(TargetDomain domain, TypeFullName entityName, Location location) => new CSRecordEntity(domain, entityName, location);
        private static TargetMember MemberFactory(TargetEntity entity, string name, Location location) => new CSRecordMember(entity, name, location);

        protected override void OnProcessEntityAttributes(TargetEntity entity, Location location, ImmutableArray<AttributeData> entityAttributes)
        {
            // not needed yet
        }

        protected override void OnProcessMemberAttributes(TargetMember member, Location location, ImmutableArray<AttributeData> memberAttributes)
        {
            // not needed yet
        }

        public CSRecordSyntaxReceiver() : base(DomainFactory, EntityFactory, MemberFactory)
        {
        }
    }
}
