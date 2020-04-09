import { BandPreviewModel } from '../band/BandPreviewModel';
import { SongPreviewModel } from '../song/song-preview-model';

export class AlbumViewModel
{
    id: string;
    title: string;
    description: string;
    url: string;
    startRecordDate?: Date;
    releaseDate: Date;
    band: BandPreviewModel;
    songs: SongPreviewModel[];
}
