const mongoose = require('mongoose')

const userSchema = new mongoose.Schema({
  firstName: String,
  lastName: String,
  birthDate: Date,
  birthPlace: String,
  countryId:Number,
  gender:Boolean,
  maidenName:String,
  municipalityId:Number,
  personalNumber:String
})

module.exports = mongoose.model('Users', userSchema)
    // FirstName = "Rinor",
    //             LastName = "Mustafa",
    //             BirthDate = DateTime.Now.AddYears(-20),
    //             BirthPlace = "Prishtine",
    //             CountryId = 2,
    //             Gender = true,
    //             MaidenName = null,
    //             MunicipalityId = 19,
    //             PersonalNumber = "1242691980"