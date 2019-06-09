const boom = require('boom')
const Users = require('../models/User')

exports.getUsers = async (req, res) => {
    try {
        const users = await Users.find()
        return users
    } catch (error) {
        throw boom.boomify(error)
    }
}

exports.addUser = async (req, res) => {
    try {
        const user = new Users(req.body)
        user.save()
        return user
    } catch (error) {
        throw boom.boomify(error)
    }
}
exports.getByPersonalNumber = async(req, res) => {
    try {
        const personalNumber = req.params.id;
        const user = Users.findOne({ "personalNumber": personalNumber });
        return user;
    } catch (error) {
        throw boom.boomify(error);
    }
}