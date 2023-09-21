using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel

public class Pet
{
  {
    public int id { get; set; }
    public string PetName { get; set; }
    public enum PetBreedType { get; set; }
    public enum PetColorType { get; set; }
    public string CheckedInAt { get; set; }
    public int petOwnerid { get; set; }
  }

}

