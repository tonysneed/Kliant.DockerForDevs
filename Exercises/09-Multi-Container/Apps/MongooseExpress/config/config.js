module.exports = {
  development: {
    rootPath: require('path').normalize(__dirname + '/..'),
    db: 'mongodb://localhost:27017/local'
  },
  staging: {
    rootPath: require('path').normalize(__dirname + '/..'),
    db: 'mongodb://my-mongodb/local'
  },
};
