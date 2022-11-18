import { Image } from "../image/image";

export interface Room {
    id: number;
    roomNumber: number;
    sectionId: number;
    image?: Image
}