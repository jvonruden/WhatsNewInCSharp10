﻿using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using WhatsNewInCSharp10;

//DemonstrateGlobalUsingNamespaces();
//DemonstrateFileScopedNamespaces();
//DemonstrateRecordStructs();
//DemonstrateSealedRecordToString();
//DemonstrateParameterlessStructConstructors();
//DemonstrateMixingDeclarationsAndVariablesInDeconstruction();
//DemonstrateWithExpressionsAndAnonymousTypes();
//DemonstrateExtendedPropertyPatterns();
//DemonstrateBetterLambdas();
//DemonstrateConstantInterpolatedStrings();
//DemonstrateInterpolatedStringImprovements();
//DemonstrateCallerArgumentExpression();
//DemonstrateStaticAbstractMembersInInterfaces();

// https://github.com/dotnet/csharplang/issues/3428
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/GlobalUsingDirective.md
static void DemonstrateGlobalUsingNamespaces() =>
	WriteLine($"Hi, Pi is {Math.PI}");

// https://github.com/dotnet/csharplang/issues/137
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/file-scoped-namespaces.md
static void DemonstrateFileScopedNamespaces()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}

// https://github.com/dotnet/csharplang/issues/4334
static void DemonstrateRecordStructs()
{
	var customer = new StructCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);
}

// https://github.com/dotnet/csharplang/issues/4174
static void DemonstrateSealedRecordToString()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	WriteLine(customer);

	var sealedCustomer = new SealedToStringCustomer(Guid.NewGuid(), "Jason");
	WriteLine(sealedCustomer);
}

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/parameterless-struct-constructors.md
static void DemonstrateParameterlessStructConstructors()
{
	var point = new Point { X = 1, Y = 2 };
	WriteLine(point);
}

// https://github.com/dotnet/csharplang/issues/125
static void DemonstrateMixingDeclarationsAndVariablesInDeconstruction()
{
	var customer = new RecordCustomer(Guid.NewGuid(), "Jason");
	(var id, var name) = customer;
	WriteLine($"{id}, {name}");
	(var differentId, name) = customer;
	WriteLine($"{differentId}, {name}");
}

static void DemonstrateWithExpressionsAndAnonymousTypes()
{
	var customer = new { Id = Guid.NewGuid(), Name = "Jason" };
	var differentCustomer = customer with { Name = "Jane" };
	WriteLine(differentCustomer);
}

// https://github.com/dotnet/csharplang/issues/4394
static void DemonstrateExtendedPropertyPatterns()
{
	var recordCustomer = new RecordCustomer(Guid.NewGuid(), "Jason");

	if (recordCustomer is RecordCustomer { Name: { Length: >= 5 } })
	{
		WriteLine("Old check works.");
	}

	if (recordCustomer is RecordCustomer { Name.Length: >= 5 })
	{
		WriteLine("New check works.");
	}
}

// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/lambda-improvements.md
static void DemonstrateBetterLambdas()
{
	var recordCustomer = new RecordCustomer(Guid.NewGuid(), "Jason");
	var customerProcessor1 = new Func<RecordCustomer, BigInteger>(
		customer => customer.Name.Length + BigInteger.Parse(customer.Id.ToString("N"), NumberStyles.HexNumber));

	WriteLine($"{nameof(customerProcessor1)} : {customerProcessor1(recordCustomer)}");

	var customerProcessor2 = (RecordCustomer customer) =>
		customer.Name.Length + BigInteger.Parse(customer.Id.ToString("N"), NumberStyles.HexNumber);

	WriteLine($"{nameof(customerProcessor2)} : {customerProcessor2(recordCustomer)}");

	var oldMultiplier = new Func<int, int, int>((x, y) => x * y);
	var newMultiplier = (int x, int y) => x + y;
	WriteLine(oldMultiplier(3, 4));
	WriteLine(newMultiplier(3, 4));
}

// https://github.com/dotnet/csharplang/issues/2951
// https://github.com/dotnet/csharplang/blob/main/proposals/csharp-10.0/constant_interpolated_strings.md
static void DemonstrateConstantInterpolatedStrings()
{
	WriteLine(MethodNames.NamesViaHardCodedConcatenation);
	WriteLine(MethodNames.NamesViaConcatenation);
	WriteLine(MethodNames.NamesViaInterpolation);
}

static void DemonstrateInterpolatedStringImprovements()
{
}

static void DemonstrateCallerArgumentExpression()
{
	// It would've been nice if the "nameof(parameter)" feature would've made it into C# 10,
	// but it looks like it's getting pushed out...but keep it it in mind.
	// https://github.com/dotnet/csharplang/issues/373
	static void PrintBooleanResult(bool result,
		[CallerMemberName] string? callerMemberName = null, [CallerArgumentExpression("result")] string? callerArgumentExpression = null) =>
			WriteLine($"{result} from {callerMemberName} doing {callerArgumentExpression}");

	PrintBooleanResult(Math.PI > Math.Sqrt(Math.PI));
}

// https://github.com/dotnet/csharplang/issues/4436
static void DemonstrateStaticAbstractMembersInInterfaces()
{

}