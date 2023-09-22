using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace pet_hotel
{
  // enum = list of const values
  public enum PetBreedType 
  {
    Husky, 
    Shepherd, 
    Poodle, 
    Beagle, 
    Bulldog, 
    Terrier, 
    Boxer, 
    Labrador, 
    Retriever 
  }
  public enum PetColorType 
  { 
    White, 
    Black, 
    Golden, 
    Tricolor, 
    Spotted 
  }

  
  public class Pet
  {
    // EF knows this is primary serial key
    public int id { get; set; }
    public string name { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreedType breed { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColorType color { get; set; }

    [ForeignKey("OwnedBy")]
    public int petOwnerid { get; set; }
    // PetOwner obj from the DB ( using joins )
    public PetOwner petOwner { get; set; }
    public DateTime checkedInAt { get; set; }

    // whenever new pet instance is created this constructor will get the current date & time
    public Pet()
    {
      checkedInAt = DateTime.Now;
    }
  }
}



