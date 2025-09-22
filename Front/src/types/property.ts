import type { Owner } from "./owner";

export interface Property {
  id: string;
  name: string;
  address: string;
  price: number;
  codeInternal: string;
  year?: number;
  imageUrl: string;
  owner: Owner;
}