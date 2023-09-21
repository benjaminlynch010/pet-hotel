using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public class Pet
  {
      public int Id { get; set; }
      public string PetName { get; set; }
      public enum PetBreedType { Shepherd, Poodle, Beagle, Bulldog,Terrier, Boxer, Labrador, Retriever }
      public enum PetColorType { White, Black, Golden, Tricolor, Spotted }
      public DateTime CheckedInAt { get; set; }
      public int PetOwnerid { get; set; }

  }
}



