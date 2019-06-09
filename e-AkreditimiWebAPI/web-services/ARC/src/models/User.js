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
