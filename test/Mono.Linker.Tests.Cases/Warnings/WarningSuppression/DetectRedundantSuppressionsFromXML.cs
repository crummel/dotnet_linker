// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Mono.Linker.Tests.Cases.Expectations.Assertions;
using Mono.Linker.Tests.Cases.Expectations.Helpers;
using Mono.Linker.Tests.Cases.Expectations.Metadata;

namespace Mono.Linker.Tests.Cases.Warnings.WarningSuppression
{
	[SkipKeptItemsValidation]
	[ExpectedNoWarnings]
	[SetupLinkAttributesFile ("DetectRedundantSuppressionsFromXML.xml")]
	public class DetectRedundantSuppressionsFromXML
	{
		public static void Main ()
		{
			DetectRedundantSuppressions.Test ();
		}

		[ExpectedWarning ("IL2121", "IL2109", ProducedBy = ProducedBy.Trimmer)]
		public class DetectRedundantSuppressions
		{
			// The warning should ideally point to XML.
			// https://github.com/dotnet/linker/issues/2923
			[ExpectedWarning ("IL2121", "IL2026", ProducedBy = ProducedBy.Trimmer)]
			public static void Test ()
			{
				DoNotTriggerWarning ();
			}

			class SuppressedOnType : DoNotTriggerWarningType { }

			static void DoNotTriggerWarning () { }

			class DoNotTriggerWarningType { }
		}
	}
}