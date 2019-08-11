﻿using GraphQL.Builders;
using GraphQL.Types;
using System.Collections.Generic;

namespace Eklee.Azure.Functions.GraphQl.Queries
{
	public interface IModelMemberQueryArgumentProvider
	{
		QueryArguments GetQueryArguments(IEnumerable<ModelMember> modelMembers);

		void PopulateConnectionBuilder<TSource>(
			ConnectionBuilder<ModelConventionType<TSource>, object> connectionBuilder,
			IEnumerable<ModelMember> modelMembers);
	}
}
