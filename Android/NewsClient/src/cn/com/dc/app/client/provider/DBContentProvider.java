package cn.com.dc.app.client.provider;

import java.util.HashMap;

import android.content.ContentProvider;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.UriMatcher;
import android.content.res.Resources;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.provider.LiveFolders;

public class DBContentProvider extends ContentProvider {
	/**
     * A projection map used to select columns from the database
     */
    private static HashMap<String, String> sNotesProjectionMap;

    /**
     * A projection map used to select columns from the database
     */
    private static HashMap<String, String> sLiveFolderProjectionMap;
    
    private static final int READ_NOTE_NOTE_INDEX = 1;
    private static final int READ_NOTE_TITLE_INDEX = 2;
    /*
     * Constants used by the Uri matcher to choose an action based on the pattern
     * of the incoming URI
     */
    // The incoming URI matches the Notes URI pattern
    private static final int NEWS = 1;

    // The incoming URI matches the Note ID URI pattern
    private static final int NEWS_ID = 2;

    // The incoming URI matches the Live Folder URI pattern
    private static final int LIVE_FOLDER_NOTES = 3;

    /**
     * A UriMatcher instance
     */
    private static final UriMatcher sUriMatcher;

    // Handle to a new DatabaseHelper.
    private SimpleSQLiteHelper mOpenHelper;

    /**
     * A block that instantiates and sets static objects
     */
    static {

        /*
         * Creates and initializes the URI matcher
         */
        // Create a new instance
        sUriMatcher = new UriMatcher(UriMatcher.NO_MATCH);

        // Add a pattern that routes URIs terminated with "notes" to a NOTES operation
        sUriMatcher.addURI(DCNews.AUTHORITY, "news", NEWS);

        // Add a pattern that routes URIs terminated with "notes" plus an integer
        // to a note ID operation
        sUriMatcher.addURI(DCNews.AUTHORITY, "news/#", NEWS_ID);

        // Add a pattern that routes URIs terminated with live_folders/notes to a
        // live folder operation
        sUriMatcher.addURI(DCNews.AUTHORITY, "live_folders/notes", LIVE_FOLDER_NOTES);

        /*
         * Creates and initializes a projection map that returns all columns
         */

        // Creates a new projection map instance. The map returns a column name
        // given a string. The two are usually equal.
        sNotesProjectionMap = new HashMap<String, String>();

        // Maps the string "_ID" to the column name "_ID"
        sNotesProjectionMap.put(DCNews.News._ID, DCNews.News._ID);

        // Maps "title" to "title"
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_TITLE, DCNews.News.COLUMN_NAME_TITLE);

        // Maps "note" to "note"
//        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_NOTE, DCNews.News.COLUMN_NAME_NOTE);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_CLICKED, DCNews.News.COLUMN_NAME_CLICKED);
        
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_COMMENTSUM, DCNews.News.COLUMN_NAME_COMMENTSUM);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_CONTENT, DCNews.News.COLUMN_NAME_CONTENT);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_CREATE_DATE, DCNews.News.COLUMN_NAME_CREATE_DATE);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_DEFAULTNEWS, DCNews.News.COLUMN_NAME_DEFAULTNEWS);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_GENTIME, DCNews.News.COLUMN_NAME_GENTIME);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_IDNEWS, DCNews.News.COLUMN_NAME_IDNEWS);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_IMAGEURL, DCNews.News.COLUMN_NAME_IMAGEURL);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_ITEMID, DCNews.News.COLUMN_NAME_ITEMID);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_KEYWORD, DCNews.News.COLUMN_NAME_KEYWORD);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_MODIFICATION_DATE, DCNews.News.COLUMN_NAME_MODIFICATION_DATE);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_NEWSURL, DCNews.News.COLUMN_NAME_NEWSURL);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_USERID, DCNews.News.COLUMN_NAME_USERID);
        
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_USERNAME, DCNews.News.COLUMN_NAME_USERNAME);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_VERIFYID, DCNews.News.COLUMN_NAME_VERIFYID);
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_WRITER, DCNews.News.COLUMN_NAME_WRITER);
        
        

        // Maps "created" to "created"
        sNotesProjectionMap.put(DCNews.News.COLUMN_NAME_CREATE_DATE,
        		DCNews.News.COLUMN_NAME_CREATE_DATE);

        // Maps "modified" to "modified"
        sNotesProjectionMap.put(
        		DCNews.News.COLUMN_NAME_MODIFICATION_DATE,
        		DCNews.News.COLUMN_NAME_MODIFICATION_DATE);

        /*
         * Creates an initializes a projection map for handling Live Folders
         */

        // Creates a new projection map instance
        sLiveFolderProjectionMap = new HashMap<String, String>();

        // Maps "_ID" to "_ID AS _ID" for a live folder
        sLiveFolderProjectionMap.put(LiveFolders._ID, DCNews.News._ID + " AS " + LiveFolders._ID);

        // Maps "NAME" to "title AS NAME"
        sLiveFolderProjectionMap.put(LiveFolders.NAME, DCNews.News.COLUMN_NAME_TITLE + " AS " +
            LiveFolders.NAME);
    }
    
    
	@Override
	public int delete(Uri uri, String where, String[] whereArgs) {
		// TODO
		// Opens the database object in "write" mode.
        SQLiteDatabase db = mOpenHelper.getWritableDatabase();
        String finalWhere;

        int count;

        // Does the delete based on the incoming URI pattern.
        switch (sUriMatcher.match(uri)) {

            // If the incoming pattern matches the general pattern for notes, does a delete
            // based on the incoming "where" columns and arguments.
            case NEWS:
                count = db.delete(
                    DCNews.News.TABLE_NAME,  // The database table name
                    where,                     // The incoming where clause column names
                    whereArgs                  // The incoming where clause values
                );
                break;

                // If the incoming URI matches a single note ID, does the delete based on the
                // incoming data, but modifies the where clause to restrict it to the
                // particular note ID.
            case NEWS_ID:
                /*
                 * Starts a final WHERE clause by restricting it to the
                 * desired note ID.
                 */
                finalWhere =
                        DCNews.News._ID +                              // The ID column name
                        " = " +                                          // test for equality
                        uri.getPathSegments().                           // the incoming note ID
                            get(DCNews.News.NOTE_ID_PATH_POSITION)
                ;

                // If there were additional selection criteria, append them to the final
                // WHERE clause
                if (where != null) {
                    finalWhere = finalWhere + " AND " + where;
                }

                // Performs the delete.
                count = db.delete(
                    DCNews.News.TABLE_NAME,  // The database table name.
                    finalWhere,                // The final WHERE clause
                    whereArgs                  // The incoming where clause values.
                );
                break;

            // If the incoming pattern is invalid, throws an exception.
            default:
                throw new IllegalArgumentException("Unknown URI " + uri);
        }

        /*Gets a handle to the content resolver object for the current context, and notifies it
         * that the incoming URI changed. The object passes this along to the resolver framework,
         * and observers that have registered themselves for the provider are notified.
         */
        getContext().getContentResolver().notifyChange(uri, null);

        // Returns the number of rows deleted.
        return count;
        
	}

	@Override
	public String getType(Uri uri) {
		/**
	        * Chooses the MIME type based on the incoming URI pattern
	        */
	       switch (sUriMatcher.match(uri)) {

	           // If the pattern is for notes or live folders, returns the general content type.
	           case NEWS:
	           case LIVE_FOLDER_NOTES:
	               return DCNews.News.CONTENT_TYPE;

	           // If the pattern is for note IDs, returns the note ID content type.
	           case NEWS_ID:
	               return DCNews.News.CONTENT_ITEM_TYPE;

	           // If the URI pattern doesn't match any permitted patterns, throws an exception.
	           default:
	               throw new IllegalArgumentException("Unknown URI " + uri);
	       }
	}

	@Override
	public Uri insert(Uri uri, ContentValues initialValues) {

		switch (sUriMatcher.match(uri)) {
			case NEWS :
				return insertNews(uri,initialValues);
			case NEWS_ID:
				break;
			default :
				break;
		}
        
        // If the insert didn't succeed, then the rowID is <= 0. Throws an exception.
        throw new SQLException("Failed to insert row into " + uri);
	}
	
	
	private Uri insertNews(Uri uri, ContentValues initialValues)
	{
		// A map to hold the new record's values.
        ContentValues values;

        // If the incoming values map is not null, uses it for the new values.
        if (initialValues != null) {
            values = new ContentValues(initialValues);

        } else {
            // Otherwise, create a new value map
            values = new ContentValues();
        }

        // Gets the current system time in milliseconds
        Long now = Long.valueOf(System.currentTimeMillis());

        // If the values map doesn't contain the creation date, sets the value to the current time.
        if (values.containsKey(DCNews.News.COLUMN_NAME_CREATE_DATE) == false) {
            values.put(DCNews.News.COLUMN_NAME_CREATE_DATE, now);
        }

        // If the values map doesn't contain the modification date, sets the value to the current
        // time.
        if (values.containsKey(DCNews.News.COLUMN_NAME_MODIFICATION_DATE) == false) {
            values.put(DCNews.News.COLUMN_NAME_MODIFICATION_DATE, now);
        }

        // If the values map doesn't contain a title, sets the value to the default title.
        if (values.containsKey(DCNews.News.COLUMN_NAME_TITLE) == false) {
            Resources r = Resources.getSystem();
            values.put(DCNews.News.COLUMN_NAME_TITLE, r.getString(android.R.string.untitled));
        }

        // If the values map doesn't contain note text, sets the value to an empty string.
        if (values.containsKey(DCNews.News.COLUMN_NAME_NOTE) == false) {
            values.put(DCNews.News.COLUMN_NAME_NOTE, "");
        }

        // Opens the database object in "write" mode.
        SQLiteDatabase db = mOpenHelper.getWritableDatabase();

        // Performs the insert and returns the ID of the new note.
        long rowId = db.insert(
            DCNews.News.TABLE_NAME,        // The table to insert into.
            DCNews.News.COLUMN_NAME_NOTE,  // A hack, SQLite sets this column value to null
                                             // if values is empty.
            values                           // A map of column names, and the values to insert
                                             // into the columns.
        );

        // If the insert succeeded, the row ID exists.
        if (rowId > 0) {
            // Creates a URI with the note ID pattern and the new row ID appended to it.
            Uri noteUri = ContentUris.withAppendedId(DCNews.News.CONTENT_ID_URI_BASE, rowId);

            // Notifies observers registered against this provider that the data changed.
            getContext().getContentResolver().notifyChange(noteUri, null);
            return noteUri;
        }
        throw new SQLException("Failed to insert row into " + uri);
	}
	
	@Override
	public boolean onCreate() {
		// TODO
		mOpenHelper = new SimpleSQLiteHelper();
		mOpenHelper.open(getContext());
		
		return true;
	}

	@Override
	public Cursor query(Uri uri, String[] projection, String selection,
			String[] selectionArgs, String sortOrder) {
		// TODO
		return null;
	}

	@Override
	public int update(Uri uri, ContentValues values, String selection,
			String[] selectionArgs) {
		// TODO
		return 0;
	}
	
}
