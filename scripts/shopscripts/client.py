import requests


def build_products_request(base_url, category=None):
    params = {"category": category} if category else None
    return requests.Request("GET", f"{base_url}/products", params=params).prepare()


def fetch_products(base_url, category=None, session=None):
    session = session or requests.Session()
    response = session.send(build_products_request(base_url, category), timeout=5)
    response.raise_for_status()
    return response.json()
