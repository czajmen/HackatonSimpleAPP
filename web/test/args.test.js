const test = require('node:test');
const assert = require('node:assert');
const { parseArgs } = require('../lib/args');

test('parseArgs defaults to port 3000', () => {
  assert.deepStrictEqual(parseArgs([]), { port: 3000 });
});

test('parseArgs reads --port', () => {
  assert.deepStrictEqual(parseArgs(['--port', '8080']), { port: 8080 });
});
