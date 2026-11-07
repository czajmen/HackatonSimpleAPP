const express = require('express');
const { parseArgs } = require('./lib/args');
const { totalPrice, groupByCategory } = require('./lib/cart');

const { port } = parseArgs(process.argv.slice(2));
const app = express();
app.use(express.json());

app.get('/health', (req, res) => res.json({ status: 'ok' }));

app.post('/cart/total', (req, res) => {
  const items = req.body.items || [];
  res.json({ total: totalPrice(items), groups: groupByCategory(items) });
});

app.listen(port, () => console.log(`agent-shop-web on :${port}`));
