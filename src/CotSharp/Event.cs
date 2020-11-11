using System.Diagnostics;
using System.Xml.Serialization;

namespace CotSharp
{
    [DebuggerStepThrough]
    [XmlRoot("event")]
    [XmlType(TypeName = "event")]
    public class Event
    {
        /// <summary>
        /// The access field is intended to indicates who has access to this
        /// event. (e.g. unrestricted, nato, army, coalition...)
        /// It is currently defined as a string, and is optional in V2.0.
        /// Future version of the event schema will provide formal
        /// definition of this field.
        /// </summary>
        [XmlAttribute("access")]
        public string Access { get; set; }

        /// <summary>
        ///<para>format = XML schema defined outside of this document</para>
        /// <para>Detail entities...</para>
        /// <para>
        /// The "detail" entity is intended to carry information that is
        ///specific to smaller communities of producers and consumers and
        ///require more intimate knowledge of the operating domain.  For
        ///example, mensurated "target" events may come from dramatically
        ///different sources and need to propagate dramatically different
        ///"detail" information.  A close-air-support mission will augment
        ///target details with initial point and callsign details to
        ///facilitate coordination of weapon delivery.  In contrast, a
        ///mission planning system may augment planned targets with target
        ///catalog information and weapon fuzing requirements.
        /// </para>
        /// <para>
        /// Because the "details" portion of the event are of interest only to
        ///a subset of subscribers, that entity may be mentioned by reference
        ///when the event is communicated.  This reduces the congestion when
        ///events are transmitted over bandwidth limited links and also
        ///prevents the retransmission of static data elements.
        /// </para>
        /// </summary>
        [XmlElement("detail")]
        public Detail Detail { get; set; }

        /// <summary>
        /// format = character-character
        ///   The "how" attribute gives a hint about how the coordinates were
        ///   generated.  It is used specifically to relay a hint about the
        ///   types of errors that may be expected in the data and to weight the
        ///   data in systems that fuse multiple inputs.  For example,
        ///   coordinates transcribed by humans may have digit transposition,
        ///   missing or repeated digits, estimated error bounds, etc.  As such,
        ///   they may require special attention as they propagate through the
        ///   kill chain (e.g., they may require an additional review).
        ///   Similarly, machine generated coordinates derived solely from
        ///   magnetic sources may be subject to known anomalies in certain
        ///   geographical areas, etc.
        ///       h - human entered or modified (someone typed the coordinates)
        ///           e - estimated (a swag by the user)
        ///           c - calculated (user probably calculated value by hand)
        ///           t - transcribed (from voice, paper, ...)
        ///           p - cut and paste from another window
        ///       m - machine generated
        ///           i - mensurated (from imagery)
        ///           g - derived from GPS receiver
        ///           m - magnetic    - derived from magnetic sources
        ///           s - simulated   - out of a simulation
        ///           f - fused       - corroborated from multiple sources
        ///           c - configured  - out of a configuration file
        ///           p - predicted   - prediction of future (e.g., a from a tracker)
        ///           r - relayed     - imported from another system (gateway)
        /// As with other compound fields, the elements of the how field
        /// will be delimited by the field separator character "-".  E.g,
        /// A coordinate mensurated from imagery would have a how field of "m-i".
        /// </summary>
        [XmlAttribute("how")]
        public string How { get; set; }

        /// <summary>
        ///<para>
        /// The opex field is intended to indicate that the event is part of a
        ///live operation, an exercise, or a simulation.  For backward compatibility, absence
        ///of the opex indicates "no statement", which will be interpreted in
        ///an installation specific manner.
        /// </para>
        /// <para>
        /// opex="o-&lt;name&gt;" or "e-&lt;nickname&gt;"  or "s-&lt;nickname&gt;",
        ///where "-&lt;name&gt;" is optional.  That is, it is permissible to
        ///specify only "o", "e", or "s" for the opex value.
        /// </para>
        /// <para>
        /// o = operations
        ///e = exercise
        ///s = simulation
        /// </para>
        /// </summary>
        [XmlAttribute("opex")]
        public string Opex { get; set; }

        [XmlElement("point")]
        public Point Point { get; set; }

        /// <summary>
        ///<para>format - digit-character-character as defined below</para>
        /// <para>
        /// The QoS attribute will determine the preferential treatment events
        ///receive as they proceed through the kill chain.  The field has
        ///several distinct but related components.
        /// </para>
        /// <para>
        /// A "priority" value indicates queuing and processing order for
        ///competing events.  At a processing bottleneck (e.g., bandwidth
        ///limited link) high priority events will be processed before lower
        ///priority events.  Priority determines queuing order at a
        ///bottleneck.
        /// </para>
        /// <para>
        ///    9 - highest (most significant) priority
        ///    0 - lowest (least significant) priority
        /// </para>
        /// <para>
        /// A "overtaking" value indicates how two events for the same uid are
        ///reconciled when they "catch up" to one another.  The more recent
        ///event (by timestamp) may supersede the older event (deleting the
        ///old event) when it catches it, or it may follow the old event so
        ///that event order is preserved, or it may be routed independently
        ///of previous events.
        /// </para>
        /// <para>
        ///    r - replace - new event replaces (deletes) old event
        ///    f - follow  - new event must follow previous events
        ///    i - independent - new event processed independently of old events
        /// </para>
        /// <para>
        /// An "assurance" value indicates how much effort must be placed in
        ///delivering this particular event.  Events from sources that
        ///continually send updates (blue force tracks) or that are sent for
        ///information purposes only require a lower level of delivery
        ///effort.  Events that are singletons (sent only once) and are
        ///critical require guaranteed delivery.
        /// </para>
        /// <para>
        ///    g - guaranteed delivery (message never dropped even if delivered late)
        ///    d - deadline (message dropped only after "stale" time)
        ///    c - congestion - message dropped when link congestion encountered
        /// </para>
        /// <para> Thus, a valid QoS field looks like:</para>
        /// <para>   qos="1-r-c"</para>
        /// <para>
        ///  Note that different events with the same UID may have differing
        ///  QoS values.  This enables a graceful degradation in the presence
        ///  of congestion.  For example, a blue force tracker may output a
        ///  sequence of events with like
        ///      ... qos="1-r-c" ...  frequent, low priority updates
        ///      ... qos="1-r-c" ...
        ///      ... qos="1-r-c" ...
        ///      ... qos="5-r-d" ...  occasional "push" priority update
        ///      ... qos="1-r-c" ...
        ///      ... qos="1-r-c" ...
        ///      ... qos="9-r-g" ...  "Mayday" position report
        /// </para>
        /// </summary>
        [XmlAttribute("qos")]
        public string Qos { get; set; }

        /// <summary>
        ///The "stale" attribute defines the ending time of the event's validity
        ///interval. The start and stale fields together define an interval in time.
        ///It has the same format as time and start.
        /// </summary>
        [XmlAttribute("stale")]
        public System.DateTime Stale { get; set; }

        /// <summary>
        /// <para> format - DTG</para>
        /// <para>
        /// The "start" attribute defines the starting time of the event's validity
        ///interval. The start and stale fields together define an interval in time.
        ///It has the same format as time and stale.
        /// </para>
        /// </summary>
        [XmlAttribute("start")]
        public System.DateTime Start { get; set; }

        /// <summary>
        ///<para>
        /// The CoT XML schema includes three time values:
        ///time, start, and stale.  "time" is a time stamp placed on the event
        ///when generated. start and stale define an interval in time for which
        ///the event is valid. Example: For the scenario where we have intel
        ///reports about a meeting of terrorist operatives later in the day: An
        ///event might be generated at noon (time) to describe a ground based
        ///target which is valid from 1300 (start) until 1330 (stale).  All time
        ///fields are required. In version 1.1 of the CoT schema, the time and stale
        ///attributes together defined and interval of time for which the event was
        ///valid. In V2.0, time indicates the "birth" of an event and the start and stale pair
        ///define the validity interval.
        /// </para>
        /// <para>
        /// The "time" attribute is a time stamp indicating when an event was generated.
        ///The format of time, start, and stale are in standard date format (ISO 8601):
        ///CCYY-MM-DDThh:mm:ss.ssZ (e.g., 2002-10-05T17:01:14.00Z), where the presence of
        ///fractional seconds (including the delimeter) is optional.  Also, there is no constraint
        ///on the number of digits to use for fractional seconds.  The following are all valid:
        /// 2002-10-05T18:00:23Z,  2002-10-05T18:00:23.12Z, 2002-10-05T18:00:23.123456Z
        /// </para>
        /// </summary>
        [XmlAttribute("time")]
        public System.DateTime Time { get; set; }

        /// <summary>
        /// <para>
        ///  The "type" attribute is a composite of components delimited by the semi-colon
        ///   character. The first component of this composite attribute is defined below.
        ///   Future versions of this schema will define other components which we expect
        ///   will aid in machine filtering. Despite the exclusion of definitions
        ///   for additional components in this version of the schema, users of
        ///   this schema should expect and design an optional trailing field
        ///   delimited by the semi-colon character. This field can be ignored.
        /// </para>
        /// <para>  component1;optional field</para>
        /// <para>
        ///   The first component (component1) is a hierarchically organized hint about type.
        ///   The intention is that this hierarchy be flexible and extensible and
        ///   facilitate simple filtering, translation and display.  To
        ///   facilitate  filtering, the hierarchy needs to present key
        ///   fields in an easily parsed and logical order.  To facilitate
        ///   this, this component is a composite of fields separated by the "-" punctuation
        ///   character, so a valid type would be: x-x-X-X-x.  Using a
        ///   punctuation for field separation allows arbitrary expansion of the
        ///   type space, e.g., a-fzp-mlk-gm-...
        /// </para>
        /// <para>
        ///   Field meanings are type specific.  That is, the third field of an
        ///   "atom" type may represent air vs. ground while the same field for a
        ///   "reservation" type may represent purpose.
        /// </para>
        /// <para>
        ///   The "Atoms" portion of the type tree requires some additional
        ///   explanation past the taxonomy defined below. The "Atoms" portion of
        ///   the type tree contains CoT defined fields and part of the MIL-STD-2525
        ///   type definition. To distinguish MIL-STD-2525 type strings from CoT defined
        ///   fields, the MIL-STD-2525 types must be represented in all upper
        ///   case. Differentiation of type namespace with upper/lower case
        ///   facilitates extension of CoT types and MIL-STD-2525 types without
        ///   name space confliction. An example:
        /// </para>
        /// <para>  a-f-A-B-C-x</para>
        /// <para>
        ///   The organization of CoT and MIL-STD-2525 types can be determined
        ///   from the taxonomy below, but additional details are provided here.
        /// </para>
        /// <para>
        ///   The "Atoms" portion of the "type" tree contains the "Battle
        ///   Dimension" and  "Function ID" fields taken from MIL-STD-2525.
        ///   "Battle Dimension" is a single character taken from
        ///   MIL-STD-2525.
        /// </para>
        /// <para>
        ///   The typical 2525 representation for "Function ID" is three groups of
        ///   two characters separated by a space (e.g. "12 34 56"). The CoT
        ///   schema maps this to a "-" delimited list of characters. (e.g. "1-2-3-4-5-6").
        ///   The concatenation of the "Battle Dimension" and "Function ID" fields
        ///   from the MIL-STD-2525 specification represented in the CoT schema
        ///   will be as follows:
        /// </para>
        /// <para>  battle dimension-func id char1-func id char2- ... -func id char6</para>
        /// <para>
        ///   When an appropriate MIL-STD-2525 type exists, it should be used. If
        ///   there is a MIL-STD-2525 representation which is close, but may be
        ///   refined, a CoT extension to the 2525 type can be appended. For
        ///   example...
        /// </para>
        /// <para>  for example: a-h-X-X-X-X-X-i might represent</para>
        /// <para>
        ///   hostile MIL-STD-2525 type X-X-X-X-X  of
        ///   Israeli manufacture. Again, the CoT extension uses lower case.
        ///   Conceptually, this extension defines further branching from the
        ///   nearest MIL-STD-2525 tree point.
        /// </para>
        /// <para>
        ///   If no appropriate 2525 representation exists, a type definition can
        ///   be added to the CoT tree defined here. The resulting definition
        ///   would be represented in all lower case. For example
        /// </para>
        /// <para>  a-h-G-p-i</para>
        /// <para>  might define atoms-hostile-Ground-photon cannon-infrared.</para>
        /// <para>
        ///   The taxonomy currently looks like this: Note that the coding of the
        ///   sub fields are determined entirely by the preceding fields!) The
        ///   current type tree is defined here.
        /// </para>
        /// <para>
        ///       +--- First position, this event describes
        ///       |
        ///       V
        /// </para>
        /// <para>      a - Atoms - this event describes an actual "thing"</para>
        /// <para>
        ///           +--- CoT affiliation of these atoms
        ///           |
        ///           V
        /// </para>
        /// <para>
        ///           p - Pending
        ///           u - Unknown
        ///           a - Assumed friend
        ///           f - Friend
        ///           n - Neutral
        ///           s - Suspect
        ///           h - Hostile
        ///           j - Joker
        ///           k - Faker
        ///           o - None specified
        ///           x - Other
        /// </para>
        /// <para>
        ///               +--- Battle dimension
        ///               |    Taken from MIL-STD-2525 "Battle Dimension" (upper case)
        ///               |
        ///               V
        /// </para>
        /// <para>              See MIL-STD-2525B specification for single charcter battle dimension</para>
        /// <para>
        ///                   +--- Function (dimension specific!)
        ///                   |
        ///                   |
        ///                   V
        ///                   ...
        ///                   See MIL-STD-2525B specification for  function fields (must be upper case)
        ///                   ...
        /// </para>
        /// <para>
        ///       +--- The event describes ...
        ///       |
        ///       V
        /// </para>
        /// <para>
        ///       b - Bits - Events in the "Bit" group carry meta information
        ///                  about raw data sources.  For example, range-doppler
        ///                  radar returns or SAR imagery represent classes of
        ///                  information that are "bits".  However, tracks
        ///                  derived from such sources represent objects on the
        ///                  battlespace and this have event type "A-..."
        /// </para>
        /// <para>
        ///                  The intention with the "Bit" type is to facilitate
        ///                  the identification of germane information products.
        ///                  This hierarchy is not intended to replace more
        ///                  detailed domain-specific meta information (such as
        ///                  that contained in NITF image headers or the GMTI
        ///                  data formats), rather it is intended to provide a
        ///                  domain-neutral mechanism for rapid filtering of
        ///                  information products.
        /// </para>
        /// <para>
        ///           +--- Dimension
        ///           |
        ///           V
        /// </para>
        /// <para>
        ///           i - Imagery
        ///               e - Electro-optical
        ///               i - Infra red
        ///               s - SAR
        ///               v - video
        ///               ...
        ///           r - Radar
        ///               m - MTI data
        ///               ...
        ///           d - Sensor detection events
        ///               s - Seismic
        ///               d - Doppler
        ///               a - Acoustic
        ///               m - Motion (e.g., IR)
        ///           m - Mapping
        ///               p - Designated point (rally point, etc.)
        ///                   i - initial points
        ///                   r - rally points
        ///                   ...
        /// </para>
        /// <para>
        ///       r - Reservation/Restriction/References
        ///                  Events in this category are generally "notices"
        ///                  about specific areas.  These events are used for
        ///                  deconfliction and conveyance of significant "area"
        ///                  conditions.  Generally, the "point" entity will
        ///                  describe a conical region that completely encloses
        ///                  the affected area.  The details entity will provide
        ///                  more specific bounds on precisely the region
        ///                  affected.
        ///           u - Unsafe (hostile capability)
        ///           o - Occupied (e.g., SOF forces on ground)
        ///           c - Contaminated (NBC event)
        ///               c - chemical
        ///                   x - agents, direction,
        ///                   y
        ///                   z
        ///           f - Flight restrictions
        /// </para>
        /// <para>
        ///       t - Tasking (requests/orders)
        ///                  Events in this category are generalized requests for
        ///                  service.  These may be used to request for data
        ///                  collection, request mensuration of a specific
        ///                  object, order an asset to take action against a
        ///                  specific point.  Generally, the "details" entity
        ///                  will identify the general or specific entity being
        ///                  tasked.
        ///           s - Surveillance
        ///           r - Relocate
        ///           e - Engage
        ///           m - Mensurate
        /// </para>
        /// <para>
        ///       c - Capability (applied to an area)
        ///           s - Surveillance
        ///           r - Rescue
        ///           f - Fires
        ///               d - Direct fires
        ///               i - Indirect fires
        ///           l - Logistics (supply)
        ///               f - Fuel
        ///               ...
        ///           c - Communications
        /// </para>
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        ///The "uid" attribute is a globally unique name for this specific piece of information.
        ///Several "events" may be associated with one UID, but in that case, the latest (ordered by timestamp),
        ///overwrites all previous events for that UID.
        /// </summary>
        [XmlAttribute("uid")]
        public string Uid { get; set; }

        /// <summary>
        /// Version number
        /// </summary>
        [XmlAttribute("version")]
        public decimal Version { get; set; }
    }
}
