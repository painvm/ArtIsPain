import { Time } from '@angular/common';

export class UpsertSongCommand 
{
    entityId?: string;
    albumId?: string;
    title: string;
    order: number;
    length: Time;
}
