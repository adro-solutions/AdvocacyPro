import { Product } from '../enums/product.enum';

export class ValueList<T extends ValueBase, TKey = number> extends Array<T> {
    private keyField: string;
    constructor (keyField = 'id') {
        super();
        this.keyField = keyField;
    }

    public load(items: T[]) {
        const sortedList = items.sort((a, b) => a.name < b.name ? -1 : 1);
        this.push(...sortedList);
    }

    public item(id: TKey): T {
        return this.find(i => i[this.keyField] === id);
    }
}
export class ValueBase {
    id: number;
    name: string;

    constructor() { this.id = 0; this.name = ''; }
}

export class AgeGrouping extends ValueBase {
    constructor() { super(); }
}

export class ContactType extends ValueBase {
    constructor() { super(); }
}

export class DocumentType extends ValueBase {
    constructor() { super(); }
}

export class ReferralType extends ValueBase {
    constructor() { super(); }
}

export class ServiceCategory extends ValueBase {
    constructor() { super(); }
}

export class ServicePopulation extends ValueBase {
    constructor() { super(); }
}

export class ServiceProgram extends ValueBase {
    categoryId: number;

    constructor() {
        super();
        this.categoryId = 0;
    }
}

export class Country extends ValueBase {
    constructor() { super(); }
}

export class Ethnicity extends ValueBase {
    constructor() { super(); }
}

export class FireCause extends ValueBase {
    constructor() { super(); }
}

export class Gender extends ValueBase {
    constructor() { super(); }
}

export class LocationType extends ValueBase {
    constructor() { super(); }
}

export class Offense extends ValueBase {
    typeId: number;
    cleryReport: boolean;

    constructor() {
        super();
        this.typeId = 0;
        this.cleryReport = true;
    }
}

export class OffenseType extends ValueBase {
    constructor() { super(); }
}

export class OrganizationType extends ValueBase {
    constructor() { super(); }
}

export class Race extends ValueBase {
    code: string;

    constructor() {
        super();
        this.code = '';
    }
}

export class RelationshipType extends ValueBase {
    constructor() { super(); }
}

export class State extends ValueBase {
    code: string;

    constructor() {
        super();
        this.code = '';
    }
}

export class Status extends ValueBase {
    constructor() { super(); }
}

export class Organization extends ValueBase {
    email: string;
    city: string;
    state: string;
    zipCode: string;
    address1: string;
    address2: string;
    address3: string;
    primaryContact: string;
    description: string;
    createDate: Date;
    lastModifiedDate: Date;
    phone: string;
    fax: string;
    url: string;
    typeId: number;
    logo: string;
    product: Product;

    constructor() {
        super();
        this.email = '';
        this.city = '';
        this.state = '';
        this.zipCode = '';
        this.address1 = '';
        this.address2 = '';
        this.address3 = '';
        this.primaryContact = '';
        this.description = '';
        this.createDate = null;
        this.lastModifiedDate = null;
        this.phone = '';
        this.fax = '';
        this.url = '';
        this.typeId = null;
        this.logo = '';
        this.product = Product.AdvocacyPro;
    }
}

export class ApplicationStatus extends ValueBase {
    constructor() { super(); }
}

export class BondType extends ValueBase {
    constructor() { super(); }
}

export class DocketType extends ValueBase {
    constructor() { super(); }
}

export class InterviewerPosition extends ValueBase {
    constructor() { super(); }
}

export class Language extends ValueBase {
    constructor() { super(); }
}

export class LetterType extends ValueBase {
    constructor() { super(); }
}

export class OrderStatus extends ValueBase {
    constructor() { super(); }
}

export class OrderType extends ValueBase {
    constructor() { super(); }
}

export class PaymentCategory extends ValueBase {
    constructor() { super(); }
}

export class Payor extends ValueBase {
    constructor() { super(); }
}

export class VictimType extends ValueBase {
    constructor() { super(); }
}

export class InterviewDocumentationType extends ValueBase {
    constructor() { super(); }
}
