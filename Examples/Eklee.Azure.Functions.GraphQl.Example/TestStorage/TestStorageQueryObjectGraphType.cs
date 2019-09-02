using GraphQL.Types;
using Microsoft.Extensions.Logging;
using Eklee.Azure.Functions.GraphQl.Example.Models;
using System.Collections.Generic;
using System.Linq;

namespace Eklee.Azure.Functions.GraphQl.Example.TestStorage.Core
{
	public class TestStorageQueryConfigObjectGraphType : ObjectGraphType<object>
	{
		public TestStorageQueryConfigObjectGraphType(QueryBuilderFactory queryBuilderFactory, ILogger logger)
		{
			Name = "query";

			queryBuilderFactory.Create<Model7>(this, "GetModel7WithModel8Id", "Get Model7")
				.WithParameterBuilder()
				.WithConnectionEdgeBuilder<Model7ToModel8>()
					.WithDestinationId()
				.BuildConnectionEdgeParameters()
				.BuildQuery()
				.BuildWithListResult();


			// Find Model7 coming from Model8
			queryBuilderFactory.Create<Model7>(this, "GetModel7WithModel8FieldAndConnectionFieldDescription", "Get Model7 With Model8 Field And Connection Field Description")
				.WithParameterBuilder()
				.BeginQuery<Model8>()
				// Use field from Model8 as a starting point to search from.
				.WithProperty(x => x.Field)
				.BuildQueryResult(ctx =>
				{
					ctx.Items["model8IdList"] = ctx.GetQueryResults<Model8>().Select(x => (object)x.Id).ToList();
				})
				.WithConnectionEdgeBuilder<Model7ToModel8>()
					// Now, we match Model7ToModel8's DestinationId with Model8 Id.
					.WithDestinationIdFromSource(ctx =>
					{
						return (List<object>)ctx.Items["model8IdList"];
					})
					.WithProperty(x => x.FieldDescription)
					.BuildConnectionEdgeParameters(ctx =>
					{
						ctx.Items["model7IdList"] = ctx.GetQueryResults<Model7ToModel8>().Select(x => x.Id)
							.Distinct()
							.Select(x => (object)x).ToList();
					})
				.ThenWithQuery<Model7>()
				.WithPropertyFromSource(x => x.Id, ctx =>
				{
					return (List<object>)ctx.Items["model7IdList"];
				})
				.BuildQueryResult(ctx => { })
				.BuildQuery()
				.BuildWithListResult();

			queryBuilderFactory.Create<Model9>(this, "GetModel9ById")
				.WithParameterBuilder()
				.WithKeys()
				.BuildQuery()
				.BuildWithListResult();
		}
	}
}
