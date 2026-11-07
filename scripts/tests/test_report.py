from shopscripts.report import render_order


def test_render_order_lists_lines():
    order = {"id": 7, "customer": "Ada", "lines": [{"name": "Mouse", "quantity": 2}]}
    assert render_order(order) == "Order 7 for Ada:\n- Mouse x2\n"
