using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
	public class OffersResponseDTO
	{
		[JsonPropertyName("status")]
		public string? Status { get; set; }

		[JsonPropertyName("request_id")]
		public string? RequestId { get; set; }

		[JsonPropertyName("data")]
		public OffersWithDTO Data { get; set; }

	}
}
