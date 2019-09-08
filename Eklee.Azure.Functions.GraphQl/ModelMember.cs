﻿using System;
using FastMember;

namespace Eklee.Azure.Functions.GraphQl
{
	public class ModelMember
	{
		public ModelMember(Type sourceType, TypeAccessor typeAccessor, Member member, bool isOptional)
		{
			TypeAccessor = typeAccessor;
			Member = member;
			IsOptional = isOptional;
			SourceType = sourceType;
		}

		public bool IsOptional { get; }

		public TypeAccessor TypeAccessor { get; }

		public Member Member { get; }

		public string Name => Member.Name.ToLower();

		public string Description => Member.GetDescription();

		public bool IsString => Member.Type == typeof(string);
		public bool IsInt => Member.Type == typeof(int);
		public bool IsDate => Member.Type == typeof(DateTime) || Member.Type == typeof(DateTimeOffset);
		public bool IsBool => Member.Type == typeof(bool);
		public bool IsGuid => Member.Type == typeof(Guid);

		public Type SourceType { get; }
	}
}
