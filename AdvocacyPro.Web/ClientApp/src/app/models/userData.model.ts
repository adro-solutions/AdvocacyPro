import { Product } from '../enums/product.enum';

export class UserData {
    id: number;
    organizationId: number;
    firstName: string;
    lastName: string;
    product: Product;
    features: string[];

    constructor() { }
}
