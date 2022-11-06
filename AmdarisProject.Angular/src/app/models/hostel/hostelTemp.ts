import { Floor } from "../floor/floor";

export interface HostelTemp {
    id: number;
    hostelNumber: number;
    floors?: Floor[];
}