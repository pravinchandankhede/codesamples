<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" indent="yes"/>
    <xsl:key name="booksByAuthor" match="book" use="@authorId"/>
    <xsl:template match="/">
        <html>
            <head>
                <title>Library Catalog</title>
                <style>
                    table { border-collapse: collapse; width: 100%; margin-bottom: 20px; }
                    th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }
                    th { background-color: #f2f2f2; }
                    h2 { margin-top: 40px; }
                </style>
            </head>
            <body>
                <h1>Library Catalog</h1>
                <xsl:for-each select="library/authors/author">
                    <xsl:variable name="authorId" select="@id"/>
                    <xsl:if test="count(key('booksByAuthor', $authorId)) &gt; 0">
                        <h2>
                            <xsl:value-of select="name"/>
                            (<xsl:value-of select="@genre"/>,
                            <xsl:value-of select="@nationality"/>)
                        </h2>
                        <table>
                            <tr>
                                <th>Title</th>
                                <th>Published Year</th>
                                <th>Language</th>
                                <th>ISBN</th>
                            </tr>
                            <xsl:for-each select="key('booksByAuthor', $authorId)">
                                <tr>
                                    <td>
                                        <xsl:value-of select="title"/>
                                    </td>
                                    <td>
                                        <xsl:value-of select="publishedYear"/>
                                    </td>
                                    <td>
                                        <xsl:value-of select="@language"/>
                                    </td>
                                    <td>
                                        <xsl:value-of select="isbn"/>
                                    </td>
                                </tr>
                            </xsl:for-each>
                        </table>
                    </xsl:if>
                </xsl:for-each>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>