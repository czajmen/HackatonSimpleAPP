const axios = require('axios');

function createApiClient(baseURL) {
  return axios.create({ baseURL, timeout: 5000, headers: { Accept: 'application/json' } });
}

async function fetchProducts(client) {
  const response = await client.get('/products');
  return response.data;
}

module.exports = { createApiClient, fetchProducts };
