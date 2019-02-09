class SinglyLinkedNode:
    def __init__(self, val):
        self.val = val
        self.next = None

class DoublyLinkedNode:
    def __init__(self, val, prev):
        self.val = val
        self.prev = prev
        self.next = None
