const test = require('node:test');
const assert = require('node:assert');
const { totalPrice, groupByCategory } = require('../lib/cart');

const items = [
  { name: 'Mouse', category: 'hardware', price: 20, quantity: 2 },
  { name: 'Keyboard', category: 'hardware', price: 50 },
  { name: 'Licence', category: 'software', price: 100, quantity: 1 },
];

test('totalPrice sums price times quantity', () => {
  assert.strictEqual(totalPrice(items), 190);
});

test('groupByCategory lists item names per category', () => {
  assert.deepStrictEqual(groupByCategory(items), {
    hardware: ['Mouse', 'Keyboard'],
    software: ['Licence'],
  });
});
