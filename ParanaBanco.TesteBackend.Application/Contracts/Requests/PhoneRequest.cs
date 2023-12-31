﻿using System.ComponentModel.DataAnnotations;

using ParanaBanco.TesteBackend.Domain.Enums;

namespace ParanaBanco.TesteBackend.Application.Contracts.Requests;

public struct PhoneRequest
{
    [Required]
    [Range(11, 99)]
    public int DDD { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MinLength(8)]
    [MaxLength(9)]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Number must be numeric")]
    public string Number { get; set; }

    [Required]
    public EPhoneType Type { get; set; }
}
