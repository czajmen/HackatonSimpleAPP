from shopscripts.files import export_name, hash_password, password_matches


def test_export_name_is_a_safe_filename():
    assert export_name("Ada Lovelace", 7) == "Ada_Lovelace-7.txt"
    assert "/" not in export_name("../etc", 1)


def test_password_hash_roundtrip():
    stored = hash_password("s3cret")
    assert password_matches(stored, "s3cret")
    assert not password_matches(stored, "other")
