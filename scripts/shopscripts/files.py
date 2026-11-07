from werkzeug.security import check_password_hash, generate_password_hash
from werkzeug.utils import secure_filename


def export_name(customer, order_id):
    return secure_filename(f"{customer}-{order_id}.txt")


def hash_password(password):
    return generate_password_hash(password)


def password_matches(stored_hash, password):
    return check_password_hash(stored_hash, password)
