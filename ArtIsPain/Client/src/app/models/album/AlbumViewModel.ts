import { BandPreviewModel } from '../band/BandPreviewModel';
import { SongPreviewModel } from '../song/song-preview-model';

export class AlbumViewModel
{
    Id: string;
    Title: string;
    Description: string;
    Url: string;
    StartRecordDate?: Date;
    ReleaseDate: Date;
    Band: BandPreviewModel;
    Songs: SongPreviewModel[];
}
