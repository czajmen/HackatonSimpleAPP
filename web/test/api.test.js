const test = require('node:test');
const assert = require('node:assert');
const { createApiClient, fetchProducts } = require('../lib/api');

test('createApiClient sets base url and timeout', () => {
  const client = createApiClient('http://localhost:5000');
  assert.strictEqual(client.defaults.baseURL, 'http://localhost:5000');
  assert.strictEqual(client.defaults.timeout, 5000);
});

test('fetchProducts returns response data', async () => {
  const fake = { get: async (path) => ({ data: [{ path }] }) };
  assert.deepStrictEqual(await fetchProducts(fake), [{ path: '/products' }]);
});
