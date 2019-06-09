const subjectController = require('../controllers/SubjectController')

const routes = [
    {
        method:'GET',
        url:'/api/subjects',
        handler:subjectController.getSubjects
    },
    {
        method:'POST',
        url:'/api/subjects',
        handler:subjectController.addSubject
    },
]
module.exports = routes