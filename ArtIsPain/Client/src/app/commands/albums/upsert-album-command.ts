import { UpsertSongCommand } from './upsert-song-command';

export class UpsertAlbumCommand
{
    entityId: string;
    bandId: string;
    title: string;
    description: string;
    url: string;
    startRecordDate?: Date;
    releaseDate: Date;
    songs: UpsertSongCommand[]
}

