﻿namespace Logistics.Shared.Models;

public class CustomerDto
{
    public string Name { get; set; } = default!;
    public IEnumerable<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto>();
}
