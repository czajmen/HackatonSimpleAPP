const _ = require('lodash');

function totalPrice(items) {
  return _.sumBy(items, (item) => item.price * (item.quantity || 1));
}

function groupByCategory(items) {
  return _.mapValues(_.groupBy(items, 'category'), (group) => group.map((item) => item.name));
}

module.exports = { totalPrice, groupByCategory };
