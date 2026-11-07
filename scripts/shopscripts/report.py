from jinja2 import Template

ORDER_TEMPLATE = Template(
    "Order {{ order.id }} for {{ order.customer }}:\n"
    "{% for line in order.lines %}- {{ line.name }} x{{ line.quantity }}\n{% endfor %}"
)


def render_order(order):
    return ORDER_TEMPLATE.render(order=order)
