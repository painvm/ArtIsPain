import { Time } from '@angular/common';
import { IUpsertEntityCommand } from 'src/app/_interfaces/i-upsert-entity-command';

export class UpsertSongCommand implements IUpsertEntityCommand
{
    EntityId?: string;
    AlbumId?: string;
    Title: string;
    Order: number;
    Length: Time;
}
