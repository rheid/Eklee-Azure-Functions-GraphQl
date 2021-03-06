﻿namespace Eklee.Azure.Functions.GraphQl
{
	/// <summary>
	/// ContextValueSetRule class.
	/// </summary>
	/// <remarks>This class is used to provide support for behavioral settings for how we configure ContextValue.</remarks>
	public class ContextValueSetRule
	{
		/// <summary>
		/// The current behavior is to attempt to set the sub fields of the GraphQL query into the ContextValue's Values properties so we can attempt to leverage it in ConnectionEdge for selecting into deeper query results. Setting this behavior to true disables that. This setting is used internally.
		/// </summary>
		public bool DisableSetSelectValues { get; set; }

		/// <summary>
		/// The current behavior is to choose the first query parameter to populate context value with. This forces us to choose the specific query parameter when it is not the first parameter.
		/// </summary>
		public bool PopulateWithQueryValues { get; set; }

		/// <summary>
		/// Force an empty context value to be created.
		/// </summary>
		public bool ForceCreateContextValueIfNull { get; set; }
	}
}