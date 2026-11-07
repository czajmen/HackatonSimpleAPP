const minimist = require('minimist');

function parseArgs(argv) {
  const args = minimist(argv, { default: { port: 3000 } });
  return { port: Number(args.port) };
}

module.exports = { parseArgs };
