'use strict';

class listNode {
    constructor(value) {
        this._value = value;
        this._previous = null;
        this._next = null;
    }

    get value() {
        return this._value;
    }
    set value(node) {
        this._value = node;
    }

    get previous() {
        return this._previous;
    }
    set previous(node) {
        this._previous = node;
    }

    get next() {
        return this._next;
    }
    set next(node) {
        this._next = node;
    }

    static _boxArray(arr) {
        let boxed = [];

        if (typeof arr[0] === 'object') {
            return arr;
        }

        for (let value of arr) {
            boxed.push(new listNode(value));
        }

        return boxed;
    }
}


class LinkedList {
    //constructor
    constructor() {
        this._head = null;
        this._tail = null;
        this._length = 0;
    }

    //getters
    get first() {
        return this._head.value;
    }
    get last() {
        return this._tail.value;
    }
    get length() {
        return this._length;
    }

    //methods
    static _enchain(nodes) { //static may be incorrect
        if (nodes.length < 2) {
            return;
        }

        nodes[0].next = nodes[1];

        for (let i = 1, length = nodes.length - 1; i < length; i += 1) {
            nodes[i].previous = nodes[i - 1];
            nodes[i].next = nodes[i + 1];
        }

        nodes[nodes.length - 1].previous = nodes[nodes.length - 2];
    }

    append(...nodes) {
        nodes = listNode._boxArray(nodes);

        if (this._head === null && this._tail === null) {
            this._head = nodes[0];

        } else {
            this._tail.next = nodes[0];
            nodes[0].previous = this._tail;
        }
        this._tail = nodes[nodes.length - 1];

        LinkedList._enchain(nodes);

        this._length += nodes.length;

        return this;
    }

    prepend(...nodes) {
        nodes = listNode._boxArray(nodes);

        if (this._head === null && this._tail === null) {
            this._tail = nodes[nodes.length - 1];

        } else {
            this._head.previous = nodes[nodes.length - 1];
            nodes[nodes.length - 1].next = this._head;
        }
        this._head = nodes[0];

        LinkedList._enchain(nodes);

        this._length += nodes.length;

        return this;
    }

    insert(...nodes) {
        let index = +nodes[0],
            prevNode,
            nextNode;

        nodes = nodes.slice(1);
        nodes = listNode._boxArray(nodes);

        if (index >= this._length) {
            this.append(...nodes);
            return this;
        } else if (index < 1) {
            this.prepend(...nodes);
            return this;
        }

        nextNode = this._head
        for (let i = 0, length = index; i < length; i += 1) {
            nextNode = nextNode.next;
        }
        prevNode = nextNode.previous;

        prevNode.next = nodes[0];
        nodes[0].previous = prevNode;

        nextNode.previous = nodes[nodes.length - 1];
        nodes[nodes.length - 1].next = nextNode;

        LinkedList._enchain(nodes);
        this._length += nodes.length;

        return this;
    }

    at(index, value) {
        let node = this._head;

        for (let i = 0, length = index; i < length; i += 1) {
            node = node.next;
        }

        if (value === undefined) {
            return node.value;
        }

        node.value = value;
    }

    removeAt(index) {
        let node = this._head,
            previous,
            next;

        for (let i = 0, length = index; i < length; i += 1) {
            node = node.next;
        }

        previous = node.previous;
        next = node.next;

        if (previous !== null && next !== null) {
            previous.next = next;
            next.previous = previous;
        } else if (previous === null && next === null) {
            this._head = null;
            this._tail = null;
        } else if (previous === null) {
            this._head = next;
        } else if (next === null) {
            this._tail = previous;
        }

        this._length -= 1;

        return node.value;
    }

    toArray() {
        let result = [];

        for (let value of this) {
            result.push(value);
        }

        return result;
    }

    toString() {
        return this.toArray().join(' -> ');
    }
}

LinkedList.prototype[Symbol.iterator] = function*() {
    let node = this._head;

    while (node !== null) {
        yield node.value;
        node = node.next;
    }
};

const list = new LinkedList().append(1, 2).insert(0, 3, 4);

module.exports = LinkedList;