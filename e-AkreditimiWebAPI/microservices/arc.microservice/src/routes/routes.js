const userController = require('../controllers/UserController')

const routes = [
    {
        method:'GET',
        url:'/api/users',
        handler:userController.getUsers
    },
    {
        method:'POST',
        url:'/api/users',
        handler:userController.addUser
    },
    {
        method:'GET',
        url:'/api/users/:id',
        handler:userController.getByPersonalNumber
    },
]
module.exports = routes