﻿namespace WhatsNewInCSharp10.Company.Models;

public sealed class Customer
{
	public Customer(Guid id, string name) =>
		(this.Id, this.Name) = (id, name);

	public int GetNameLength() => this.Name.Length;

	public override string ToString() => $"{this.Id}, {this.Name}";

	public Guid Id { get; init; }
	public string Name { get; init; }
}
