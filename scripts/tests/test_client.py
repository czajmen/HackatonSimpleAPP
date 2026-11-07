from shopscripts.client import build_products_request


def test_request_without_category():
    assert build_products_request("http://shop.test").url == "http://shop.test/products"


def test_request_with_category():
    request = build_products_request("http://shop.test", "hardware")
    assert request.url == "http://shop.test/products?category=hardware"
