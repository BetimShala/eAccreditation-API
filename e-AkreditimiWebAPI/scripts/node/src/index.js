const fastify = require('fastify')({
    logger: true
})
const mongoose = require('mongoose')
const routes = require('./routes/routes')
fastify.get('/', async (request, reply) => {
    return 'This is ARC API built with Node.js and Fastify for educational purpose'
})

routes.forEach((route, index) => {
    fastify.route(route);
})
// Run the server!
const start = async () => {
    try {
        await fastify.listen(3000, '0.0.0.0', function() {
            console.log('Listening to port:  ' + 3000);
        });
        fastify.log.info(`Server listening on ${fastify.server.address().port}`)
    } catch (err) {
        fastify.log.error(err)
        process.exit(1)
    }
}

mongoose.connect('mongodb://localhost/ARC')
    .then(() => console.log('DB connected...'))
    .catch(err => console.log(err));
start()