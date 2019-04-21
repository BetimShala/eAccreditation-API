const boom = require('boom')
const Subjects = require('../models/Subject')

exports.getSubjects = async (req, res) => {
    try {
        const facultyId = req.query.facultyId;
        const educationLevelId = req.query.educationLevelId;
        console.log('FacultyId: '+facultyId +' ~ Education Level Id : '+ educationLevelId);
        const subjects = Subjects.find({ "facultyId": facultyId, "educationLevelId": educationLevelId });
        return subjects;
    } catch (ex) {
        throw boom.boomify(error)
    }
}

exports.addSubject = async (req, res) => {
    try {
        const subject = new Subjects(req.body)
        subject.save()
        return subject
    } catch (error) {
        throw boom.boomify(error)
    }
}