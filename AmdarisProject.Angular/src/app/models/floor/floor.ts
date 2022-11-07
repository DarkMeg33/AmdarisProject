import { Section } from "../section/section";

export interface Floor {
    id: number,
    floorNumber: number;
    hostelId: number;
    sections?: Section[];
}