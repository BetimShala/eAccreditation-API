const mongoose = require('mongoose')

const subjectSchema = new mongoose.Schema({
    facultyId: Number,
    educationLevelId: Number,
    semesterId: Number,
    exercisesNum: Number,
    creditsNum: Number,
    consultationNum: Number,
    clinicNum: Number,
    practiceNum: Number,
    researchNum: Number,
    lecturesNum: Number,
    subjectCode: String,
    subjectName: String
})

module.exports = mongoose.model('Subjects', subjectSchema)