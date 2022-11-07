import { Floor } from "../floor/floor";

export interface Hostel {
    id: number;
    hostelNumber: number;
    floors?: Floor[];
}