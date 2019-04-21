const fastify = require('fastify')({
    logger: true
})
const mongoose = require('mongoose')
const routes = require('./routes/routes')
fastify.get('/', async (request, reply) => {
    return 'This is SEMS API built with Node.js and Fastify for educational purpose'
})

// Import Swagger Options
const swagger = require('./config/swagger')
// Register Swagger
fastify.register(require('fastify-swagger'), swagger.options)

routes.forEach((route, index) => {
    fastify.route(route);
})
// Run the server!
const start = async () => {
    try {
        await fastify.listen(3100, '0.0.0.0', function () {
            console.log('Listening to port:  ' + 3100);
        });
        fastify.swagger()
        fastify.log.info(`Server listening on ${fastify.server.address().port}`)
    } catch (err) {
        fastify.log.error(err)
        process.exit(1)
    }
}

mongoose.connect('mongodb://localhost/SEMS', { useNewUrlParser: true })
    .then(() => console.log('DB connected...'))
    .catch(err => console.log(err));
start()