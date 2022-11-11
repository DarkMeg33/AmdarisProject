import { Room } from "../room/room";

export interface Section {
    id: number;
    sectionNumber: number;
    floorId: number;
    rooms?: Room[];
}